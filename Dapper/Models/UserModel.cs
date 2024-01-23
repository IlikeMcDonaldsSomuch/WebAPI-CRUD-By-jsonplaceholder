using System;
namespace Dapper.Models
{
	public class UserModel
	{
		public int userId { get; set; }
        public int id { get; set; }
        public string? title { get; set; }
        public string? body { get; set; }
    }
}

