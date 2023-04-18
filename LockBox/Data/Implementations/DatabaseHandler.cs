using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LiteDB;
using LockBox.ViewModels;
using NLog;

namespace LockBox.Data
{
	public class DatabaseHandler : IDatabaseHandler
	{
		
		private LiteDatabase? _db;

		private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

		public void Login(string password)
		{
			try
			{
				var connectionString = @$"Filename=core.db;Journal=false;Password={password}";
				_db = new LiteDatabase(connectionString);
			}
			catch (Exception e)
			{
				Logger.Error(e, "Error while logging in");
			}
		}
		public bool Insert<T>(string collectionName, T entity)
		{
			if (_db == null) return false;

			var collection = _db.GetCollection<T>(collectionName);
			return collection.Insert(entity);
		}

		public bool Update<T>(string collectionName, T entity)
		{
			if (_db == null) return false;

			var collection = _db.GetCollection<T>(collectionName);
			return collection.Update(entity);
		}

		public bool Delete<T>(string collectionName, BsonValue id)
		{
			if (_db == null) return false;

			var collection = _db.GetCollection<T>(collectionName);
			return collection.Delete(id);
		}

		public T? GetById<T>(string collectionName, BsonValue id)
		{
			if (_db == null) return default;

			var collection = _db.GetCollection<T>(collectionName);
			return collection.FindById(id);
		}

		public IEnumerable<T>? GetAll<T>(string collectionName)
		{
			var collection = _db?.GetCollection<T>(collectionName);
			return collection?.FindAll();
		}

		public Task<object> Register(User user)
		{
			throw new NotImplementedException();
		}
	}
}