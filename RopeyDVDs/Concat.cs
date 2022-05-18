using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace RopeyDVDs
{
    public class Concat
    {
        public static DataTable concatActors(DataTable dt)
        {
            List<string> movies = new List<string>();
            HashSet<string> repetativeMovies = new HashSet<string>();
            List<List<int>> index = new List<List<int>>();
            foreach (DataRow row in dt.Rows)
            {
                movies.Add(row["DVDTitle"].ToString());
            }
            foreach (string movieName in movies)
            {
                int freq = movies.Count(f => (f == movieName));
                if (freq > 1)
                {
                    repetativeMovies.Add(movieName);
                }
            }
            foreach (string repeatMovie in repetativeMovies)
            {
                List<int> innerIndex = new List<int>();
                foreach (DataRow row in dt.Rows)
                {
                    if (row["DVDTitle"].ToString().Equals(repeatMovie))
                    {
                        innerIndex.Add(dt.Rows.IndexOf(row));
                    }
                }

                index.Add(innerIndex);
            }

            foreach (List<int> individualList in index)
            {
                string finalActorName = "";
                int count = 0;
                foreach (int i in individualList)
                {
                    if (individualList.Count() > 0)
                    {
                        if (count == individualList.Count() - 1)
                        {
                            finalActorName = finalActorName + dt.Rows[i]["ActorName"];
                            dt.Rows[i]["ActorName"] = finalActorName;
                        }
                        else
                        {
                            finalActorName = finalActorName + dt.Rows[i]["ActorName"] + ", ";
                            dt.Rows[i].Delete();
                        }
                        count++;
                    }
                }
            }

            return dt;
        }
    }
}