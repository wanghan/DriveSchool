namespace DriveSchool
{
    class SearchConditionEntry
    {
        public string Name { get; set; }
        public SearchCategory Category { get; set; }

        public SearchConditionEntry(string name, SearchCategory cate)
        {
            this.Name = name;
            this.Category = cate;
        }
    }

    public enum SearchCategory
    {
        SearchByName = 1,
        SearchByIdentity
    }
}
