public class StringCache
{ 
    public class Tag
    {
        public readonly static string PLAYER = "Player";
    }

    public class Action
    {
        public readonly static string IDLE = "New State";
        public readonly static string WIN = "Take 3";
    }

    public class Level
    {
        public readonly static string TEXT = "Level ";
        public readonly static string FILE_PATH = @"Assets\_Game\Data\lv";
        public readonly static string FILE_EXTEND = ".txt";
    }
}