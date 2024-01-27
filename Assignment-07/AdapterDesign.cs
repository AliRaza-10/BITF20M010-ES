using System;
// _______________EAXMPLE 1________
// Target interface
interface ITarget
{
    void Request();
}

// Adapter class
class Adapter
{
    public void SpecificRequest()
    {
        Console.WriteLine("Adapter's  request in example 1");
    }
}

// Adapter
class ObjectAdapter : ITarget
{
    private Adapter adapter;

    public ObjectAdapter(Adapter adapter)
    {
        this.adapter = adapter;
    }

    public void Request()
    {
        // Using Adapter's specific functionality
        adapter.SpecificRequest();
    }
}

//__________EXAMPLE 2_______
interface IDatabase
{
    void Connect();
    void ExecuteQuery();
}

// Adaptee 1 - MySQLDatabase
class MySQLDatabase
{
    public void ConnectMySQL()
    {
        Console.WriteLine("Connecting to MySQL database in example 2");
    }

    public void QueryMySQL()
    {
        Console.WriteLine("Executing query in MySQL database in example 2");
    }
}

// Adapter for MySQLDatabase
class MySQLAdapter : IDatabase
{
    private MySQLDatabase mySQLDatabase;

    public MySQLAdapter(MySQLDatabase mySQLDatabase)
    {
        this.mySQLDatabase = mySQLDatabase;
    }

    public void Connect()
    {
        mySQLDatabase.ConnectMySQL();
    }

    public void ExecuteQuery()
    {
        mySQLDatabase.QueryMySQL();
    }
}

// Adaptee 2 - MongoDB
class MongoDB
{
    public void ConnectMongoDB()
    {
        Console.WriteLine("Connecting to MongoDB in example 2");
    }

    public void QueryMongoDB()
    {
        Console.WriteLine("Executing query in MongoDB in example 2");
    }
}

// Adapter for MongoDB
class MongoDBAdapter : IDatabase
{
    private MongoDB mongoDB;

    public MongoDBAdapter(MongoDB mongoDB)
    {
        this.mongoDB = mongoDB;
    }

    public void Connect()
    {
        mongoDB.ConnectMongoDB();
    }

    public void ExecuteQuery()
    {
        mongoDB.QueryMongoDB();
    }
}

// Client code
class Program
{
    static void Main()
    {
        // __________EXAMPLE 1 ______
        Adapter adaptee = new Adapter();
        ITarget adapter = new ObjectAdapter(adaptee);
        adapter.Request(); 
        // EXAMPLE 2
         // Using MySQL via adapter
        MySQLDatabase mySQLDatabase = new MySQLDatabase();
        IDatabase mySQLAdapter = new MySQLAdapter(mySQLDatabase);
        mySQLAdapter.Connect();
        mySQLAdapter.ExecuteQuery();
        // Using MongoDB via adapter
        MongoDB mongoDB = new MongoDB();
        IDatabase mongoDBAdapter = new MongoDBAdapter(mongoDB);
        mongoDBAdapter.Connect();
        mongoDBAdapter.ExecuteQuery();
    }
}
