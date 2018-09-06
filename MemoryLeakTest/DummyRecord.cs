using System.Diagnostics;
using System.Threading;

namespace MemoryLeakTest
{
	public class DummyRecord
	{
		public int Id { get; set; }
		public string Name { get; set; }

		private static int RefCount;

		public DummyRecord()
		{
			Interlocked.Increment(ref DummyRecord.RefCount);
			Debug.WriteLine($"{nameof(DummyRecord)} Hash:{this.GetHashCode():X} {DummyRecord.RefCount}件↗");
		}

		~DummyRecord()
		{
			Interlocked.Decrement(ref DummyRecord.RefCount);
			Debug.WriteLine($"{nameof(DummyRecord)} Hash:{this.GetHashCode():X} {DummyRecord.RefCount}件↘");
		}
	}
}