using SQLite;

namespace XamarinTest.Interfaces {
    public interface ISqliteConnection {
        SQLiteConnection GetSQLiteConnection();
    }
}
