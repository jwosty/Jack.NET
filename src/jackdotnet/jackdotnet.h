/*
 * A small library to work around .NET not supporting vararg P/Invoke on all platforms (see issue for details:
 * https://github.com/dotnet/runtime/issues/48796).
 *
 * There were two possible approaches:
 *      1. Use runtime trickery to make the call happen in just the right way for each architecture (good because no
 *         stub native library shipping required)
 *      2. Hide the vararg calls behind a C stub library (good because this will "just work" on all platforms, by virtue
 *         of just relying on an actual C compiler)
 */

#ifndef JACKDOTNET_H
#define JACKDOTNET_H
#include <jack/jack.h>

jack_client_t *jackdotnet_jack_client_open_0 (const char *client_name,
    jack_options_t options,
    jack_status_t *status) JACK_OPTIONAL_WEAK_EXPORT;

jack_client_t *jackdotnet_jack_client_open_1 (const char *client_name,
    jack_options_t options,
    jack_status_t *status,
    char* server_name) JACK_OPTIONAL_WEAK_EXPORT;

#endif // JACKDOTNET_H
