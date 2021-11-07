using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BaseLogic.DB
{
    public class MongoBasicActions
    {
        private static MongoBasicActions MongoInstance = null;
        private static MongoClient Client = null;
        private static IMongoDatabase DB = null;
        private const string DBTableName = "InterviewProject";
        private const string CollectionName = "Workers";

        public delegate void MyDelegate(string msg);

        private MongoBasicActions() { }

        public static MongoBasicActions Instance()
        {
            if (MongoInstance == null)
            {
                var connectionString = GetConnectionString();
                MongoInstance = new MongoBasicActions();
                Client = new MongoClient(connectionString);
                DB = Client.GetDatabase(DBTableName);
            }
            return MongoInstance;
        }

        public async Task<List<T>> GetAllObjectsAsync<T>()
        {
            
            var collection = DB.GetCollection<T>(CollectionName);
            var filter = Builders<T>.Filter.Empty;

            return (await collection.FindAsync(filter)).ToList();
        }

        private static string GetConnectionString()
        {
            var envData = System.Environment.GetEnvironmentVariable("IsDocker");
            if (envData != null && envData.ToLower() == "true")
            {
                return "mongodb://db-mongo:27017";
            }
            return "mongodb://localhost:27017";
        }


        public async Task<T> GetObjectByIdAsync<T>(string objectId)
        {
            var isWorkerExist = await CheckIfWorkerExistsByIdAsync(objectId);
            if (isWorkerExist == false)
            {
                return default(T);
            }
            var collection = DB.GetCollection<T>(CollectionName);
            var filter = Builders<T>.Filter.Eq("ID", objectId);

            return (await collection.FindAsync(filter)).First();
        }

        public async Task<BsonDocument> GetBsonByIdAsync(string bsonId)
        {
            var isWorkerExist = await CheckIfWorkerExistsByIdAsync(bsonId);
            if (isWorkerExist == false)
            {
                return null;
            }
            var collection = DB.GetCollection<BsonDocument>(CollectionName);
            var filter = Builders<BsonDocument>.Filter.Eq("ID", bsonId);
            var bsonWorker = (await collection.FindAsync(filter)).First();
            
            return bsonWorker;
        }

        public async Task SetFieldAsync<T>(string bsonId, string fieldName, T newValue)
        {
            var isWorkerExist = await CheckIfWorkerExistsByIdAsync(bsonId);
            if (isWorkerExist == true)
            {
                var collection = DB.GetCollection<BsonDocument>(CollectionName);
                var filter = Builders<BsonDocument>.Filter.Eq("ID", bsonId);
                var update = Builders<BsonDocument>.Update.Set(fieldName, newValue);

                await collection.UpdateOneAsync(filter, update);
            }
        }

        public async Task AddToNumericFieldAsync(string bsonId, string fieldName, int valueToAdd)
        {
            var isWorkerExist = await CheckIfWorkerExistsByIdAsync(bsonId);
            if (isWorkerExist == true)
            {
                var collection = DB.GetCollection<BsonDocument>(CollectionName);
                var filter = Builders<BsonDocument>.Filter.Eq("ID", bsonId);
                var update = Builders<BsonDocument>.Update.Inc(fieldName, valueToAdd);

                await collection.UpdateOneAsync(filter, update);
            }
        }

        public async Task SetObjectDocumentAsync<T>(string objectId, T actualObject)
        {
            var collection = DB.GetCollection<T>(CollectionName);
            var workerId = objectId;
            var filter = Builders<T>.Filter.Eq("ID", workerId);
            await collection.ReplaceOneAsync(filter, actualObject);
        }

        internal async Task AddNewObjectAsync<T>(string newObjectId,T newObject)
        {
            var isWorkerExist = await CheckIfWorkerExistsByIdAsync(newObjectId);
            if (isWorkerExist == false)
            {
                var collection = DB.GetCollection<T>(CollectionName);
                await collection.InsertOneAsync(newObject);
            }
        }

        internal async Task DeleteWorkerByIdAsync(string objectId)
        {
            var isWorkerExist = await CheckIfWorkerExistsByIdAsync(objectId);
            if (isWorkerExist == true)
            {
                var collection = DB.GetCollection<BsonDocument>(CollectionName);
                var filter = Builders<BsonDocument>.Filter.Eq("ID", objectId);
                await collection.DeleteOneAsync(filter);
            }
        }

        public async Task<bool> CheckIfWorkerExistsByIdAsync(string objectId)
        {
            bool isFound;
            var collection = DB.GetCollection<BsonDocument>(CollectionName);
            var filter = Builders<BsonDocument>.Filter.Eq("ID", objectId);
            CountOptions limitCount = new CountOptions() { Limit = 1 };
            var x = await collection.CountDocumentsAsync(filter, limitCount);
            isFound = x == 1 ? true : false;
            return isFound;
        }
    }
}

