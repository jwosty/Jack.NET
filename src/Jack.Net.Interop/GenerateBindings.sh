#!/usr/bin/env bash

set -e
SCRIPT_DIR=$(dirname "$0")
echo "SCRIPT_DIR=${SCRIPT_DIR}"

CLANGSHARPPINVOKEGENERATOR_TOOL_VERSDION="18.1.0.1"
LIBCLANG_RUNTIME_VERSION="18.1.3.2"
LIBCLANG_NAME="libclang.so"
LIBCLANGSHARP_RUNTIME_VERSION="18.1.3.1"
LIBCLANGSHARP_NAME="libClangSharp.so"
LIBCLANGSHARP_TARGET_NAME="libClangSharp.so"

# On unix this is often ~/.nuget/packages/
NUGET_PACKAGES_DIR=$(dotnet nuget locals global-packages -l | cut -d " " --fields 2)

HEADERS_DIR="${SCRIPT_DIR}/../../headers/"

PACKAGE_ARCH=$(dotnet msbuild "${SCRIPT_DIR}/Jack.Net.Interop.csproj" -getProperty:NETCoreSdkRuntimeIdentifier)

#LIBCLANG_LOCATION=$(ldconfig -p | grep "${LIBCLANG_NAME}" | tr ' ' '\n' | grep -m 1 /)
LIBCLANG_LOCATION="${NUGET_PACKAGES_DIR}/libclang.runtime.${PACKAGE_ARCH}/${LIBCLANG_RUNTIME_VERSION}/runtimes/${PACKAGE_ARCH}/native/${LIBCLANG_NAME}"
LIBCLANG_DIR=$(dirname "${LIBCLANG_LOCATION}")
LIBCLANG_LINK_TARGET="${NUGET_PACKAGES_DIR}/clangsharppinvokegenerator/${CLANGSHARPPINVOKEGENERATOR_TOOL_VERSDION}/tools/net8.0/any/${LIBCLANG_NAME}"

echo C

LIBCLANGSHARP_LOCATION="${NUGET_PACKAGES_DIR}/libclangsharp.runtime.${PACKAGE_ARCH}/${LIBCLANGSHARP_RUNTIME_VERSION}/runtimes/${PACKAGE_ARCH}/native/${LIBCLANGSHARP_NAME}"
LIBCLANGSHARP_DIR=$(dirname "${LIBCLANGSHARP_LOCATION}")
LIBCLANGSHARP_LINK_TARGET="${NUGET_PACKAGES_DIR}/clangsharppinvokegenerator/${CLANGSHARPPINVOKEGENERATOR_TOOL_VERSDION}/tools/net8.0/any/${LIBCLANGSHARP_TARGET_NAME}"

#export LD_LIBRARY_PATH="${LD_LIBRARY_PATH}:${LIBCLANG_DIR}:${LIBCLANGSHARP_DIR}"

if [ ! -f "${LIBCLANG_LINK_TARGET}" ]; then
  echo cp "${LIBCLANG_LOCATION}" "${LIBCLANG_LINK_TARGET}"
  cp "${LIBCLANG_LOCATION}" "${LIBCLANG_LINK_TARGET}"
fi

if [ ! -f "${LIBCLANGSHARP_LINK_TARGET}" ]; then
  echo cp "${LIBCLANGSHARP_LOCATION}" "${LIBCLANGSHARP_LINK_TARGET}"
  cp "${LIBCLANGSHARP_LOCATION}" "${LIBCLANGSHARP_LINK_TARGET}"
fi

rm -f "$SCRIPT_DIR"/jack/*.cs

#export LD_DEBUG=libs

# TODO: consider making an actual opaque struct type to use for sigset_t and pthread_attr_t instead of just void*

dotnet ClangSharpPInvokeGenerator \
  --language c \
  --config unix-types generate-helper-types multi-file exclude-funcs-with-body \
  --output "${SCRIPT_DIR}/jack/" \
  --namespace "Jack.Net.Interop" \
  --libraryPath "libjack" \
  --include-directory "${HEADERS_DIR}" \
  --include-directory "/usr/lib/clang/18/include" \
  --additional "--include" "stdint.h" \
  --remap sigset_t=@void* \
  --remap pthread_attr_t*=@void* \
  --file-directory "${HEADERS_DIR}" \
  --file "jack/control.h" \
  --file "jack/intclient.h" \
  --file "jack/jack.h" \
  --file "jack/jslist.h" \
  --file "jack/metadata.h" \
  --file "jack/midiport.h" \
  --file "jack/ringbuffer.h" \
  --file "jack/session.h" \
  --file "jack/statistics.h" \
  --file "jack/systemdeps.h" \
  --file "jack/thread.h" \
  --file "jack/transport.h" \
  --file "jack/types.h" \
  --file "jack/uuid.h" \
  --file "jack/weakjack.h" \
  --file "jack/weakmacros.h"
