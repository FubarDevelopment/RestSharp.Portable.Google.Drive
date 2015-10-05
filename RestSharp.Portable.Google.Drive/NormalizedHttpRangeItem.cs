﻿namespace RestSharp.Portable.Google.Drive
{
    internal class NormalizedHttpRangeItem
    {
        public NormalizedHttpRangeItem(long from, long to)
        {
            From = from;
            To = to;
        }

        public long From { get; }

        public long To { get; }

        public long Length => To - From + 1;
    }
}
