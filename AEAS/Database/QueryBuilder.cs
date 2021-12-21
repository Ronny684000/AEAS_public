using System;

namespace AEAS.Database
{
    internal class QueryBuilder
    {
        public string Query {get; set;}

        public QueryBuilder SELECT(params string[] fields)
        {
            Query += "select ";
            foreach (var field in fields)
            {
                Query += Array.IndexOf(fields, field) == fields.Length - 1 ?
                    field + " " :
                    field + ", ";
            }
            return this;
        }

        public QueryBuilder FROM(string table)
        {
            Query += "from " + table + " ";
            return this;
        }

        public QueryBuilder WHERE()
        {
            Query += "where ";
            return this;
        }

        public QueryBuilder Equals(string field, object value)
        {
            Query += value.GetType() == typeof(string) ?
                field + " = " + "'" + value + "' " :
                field + " = " + value + " ";
            return this;
        }

        public QueryBuilder Equal(string field, string value)
        {
            Query += field + " = " + value + " ";
            return this;
        }

        public QueryBuilder AND()
        {
            Query += "and ";
            return this;
        }

        public QueryBuilder OR()
        {
            Query += "or ";
            return this;
        }

        public QueryBuilder NOT()
        {
            Query += "not ";
            return this;
        }

        public QueryBuilder LIKE(object value)
        {
            Query += value.GetType() == typeof(string) ?
                "like % '" + value + "'%" :
                "like % " + value + "%";
            return this;
        }

        public QueryBuilder INSERT_INTO(string table, string fields)
        {
            if (fields == "*")
            {
                Query += "insert into " + table + " ";
            }
            else
            {
                Query += "insert into " + table + "(" + fields + ") ";
            }
            return this;
        }

        public QueryBuilder VALUES(params object[][] values)
        {
            Query += "values ";
            foreach (object[] valueRow in values)
            {
                Query += "(";
                foreach (object value in valueRow)
                {
                    Query += value.GetType() == typeof(string) ? "'" + value + "'" :
                    value.ToString();
                    Query += Array.IndexOf(valueRow, value) == valueRow.Length - 1 ? 
                    " " : ", ";
                }
                Query += Array.IndexOf(values, valueRow) == values.Length - 1 ?
                    ") " : "), ";
            }
            return this;
        }

        public QueryBuilder UPDATE(string table)
        {
            Query += "update " + table + " ";
            return this;
        }

        public QueryBuilder SET()
        {
            Query += "set ";
            return this;
        }

        public QueryBuilder EXISTS(QueryBuilder innerQuery)
        {
            Query += "exists (" + innerQuery.Build() + ")";
            return this;
        }

        public QueryBuilder JOIN(string table)
        {
            Query += "join " + table + " ";
            return this;
        }

        public QueryBuilder ON()
        {
            Query += "on ";
            return this;
        }

        public string Build()
        {
            return Query;
        }
    }
}
