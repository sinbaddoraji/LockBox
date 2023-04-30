﻿using System;
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

		public static User CurrentUser;

		public static bool IsLoggedIn => CurrentUser != null;

		public bool Login(string username, string password)
		{
			try
			{
				_db ??= new LiteDatabase($"Filename={username}_core.db; Password={password};");

				var users = _db.GetCollection<User>("Users");

				CurrentUser = users.FindOne(x => x.Username == username);

				if (CurrentUser != null)
				{
					Logger.Info("Logged in as {0}", CurrentUser.Username);
				}
				else
					Logger.Info("Failed to log in as {0}", username);
			}
			catch (Exception e)
			{
				Logger.Error(e, "Error while logging in");
			}

			return IsLoggedIn;
		}

		public Guid? Insert<T>(string collectionName, T entity)
		{
			var collection = _db?.GetCollection<T>(collectionName);

			return collection?.Insert(entity);
		}

		public bool Update<T>(string collectionName, T entity)
		{
			if (_db == null) return false;

			var collection = _db.GetCollection<T>(collectionName);
			var valid =  collection.Update(entity);

			_db.Commit();

			return valid;
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

		public Task<object> Register(User user, string password)
		{
			try
			{
				_db ??= new LiteDatabase($"Filename={user.Username}_core.db; Password={password};");
				Insert("Users", user);
				return Task.FromResult<object>(true);
			}
			catch
			{
				return Task.FromResult<object>(false);
			}
		}
	}
}