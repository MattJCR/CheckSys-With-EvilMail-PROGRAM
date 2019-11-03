using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckUComputer
{
    public class PerfomanceInfoData
    {
        public Int64 CommitTotalPages;
        public Int64 CommitLimitPages;
        public Int64 CommitPeakPages;
        public Int64 PhysicalTotalBytes;
        public Int64 PhysicalAvailableBytes;
        public Int64 SystemCacheBytes;
        public Int64 KernelTotalBytes;
        public Int64 KernelPagedBytes;
        public Int64 KernelNonPagedBytes;
        public Int64 PageSizeBytes;
        public int HandlesCount;
        public int ProcessCount;
        public int ThreadCount;
    }
}
