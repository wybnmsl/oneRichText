using SqlSugar;


namespace trrrry
{
    [SugarTable("Note")]
    class Note
    {
        [SugarColumn(IsPrimaryKey =true, IsIdentity = true, IsNullable = false, ColumnName = "id")]
        public int id { get; set; }
        [SugarColumn(IsNullable = false, ColumnName = "zone")]
        public string zone { get; set; }

        [SugarColumn(IsNullable = false, ColumnName = "note")]
        public string  note{ get; set; }

        [SugarColumn(ColumnName = "text")]
        public string text { get; set; }
    }
}
