using System;
using System.Collections;
using System.Collections.Generic;
// ReSharper disable InconsistentNaming

namespace Jack.NET.Interop
{
    public unsafe partial struct _JSList : IEnumerable<nint>
    {
        public IEnumerator<nint> GetEnumerator() => new JSListEnumerator(this);

        IEnumerator IEnumerable.GetEnumerator() => new JSListEnumerator(this);

        private unsafe struct JSListEnumerator(_JSList node) : IEnumerator<nint>
        {
            private readonly _JSList InitialNode = node;
            private _JSList CurrentNode = node;

            public nint Current => (nint)this.CurrentNode.data;

            public bool MoveNext()
            {
                if (this.CurrentNode.next is not null)
                {
                    this.CurrentNode = *this.CurrentNode.next;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void Reset()
            {
                this.CurrentNode = this.InitialNode;
            }

            object IEnumerator.Current => this.Current;

            public void Dispose() { }
        }
    }
}



