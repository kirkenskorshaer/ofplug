using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ofplug.of.connector
{
	public abstract class Abstract_id_collection : IEnumerable<int>
	{
		private Queue<int> _id_cache = new Queue<int>();
		private int _current_offset = 0;
		private int _of_step;
		private string _url;
		private string _collection_name;
		private ISender _sender;

		public Abstract_id_collection(string url, string collection_name, int step, ISender sender)
		{
			_url = url;
			_of_step = step;
			_collection_name = collection_name;
			_sender = sender;
		}

		public void Replace_sender(ISender sender)
		{
			_sender = sender;
		}

		public IEnumerator<int> GetEnumerator()
		{
			bool is_more_in_of = true;
			while (is_more_in_of)
			{
				is_more_in_of = Fill_cache();

				while (_id_cache.Any())
				{
					yield return _id_cache.Dequeue();
				}
			}
		}

		private bool Fill_cache()
		{
			List<int> response = _sender.Get<List<int>>(_url + _collection_name + "/" + _current_offset + "/");
			_current_offset += _of_step;

			response.ForEach(id => _id_cache.Enqueue(id));

			return (response.Count == _of_step);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
