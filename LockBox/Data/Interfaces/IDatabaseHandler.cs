using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LiteDB;
using LockBox.ViewModels;

namespace LockBox.Data;

public interface IDatabaseHandler
{
	bool Login(string username, string password);

	Guid? Insert<T>(string collectionName, T entity);

	bool Update<T>(string collectionName, T entity);

	bool Delete<T>(string collectionName, BsonValue id);

	T? GetById<T>(string collectionName, BsonValue id);

	IEnumerable<T>? GetAll<T>(string collectionName);
	Task<object> Register(User user);
}