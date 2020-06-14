using Org.BouncyCastle.Asn1.Cms;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq.Expressions;
using System.Threading;
using System.Windows.Forms;

namespace trrrry
{
    class VirManager
    {
        static string dbPath = @"./db.db";
        SqlSugarClient db;
        public List<Note> notes;
        public string curZone;
        public string curNote;
        public string curCont;
        public List<string> zones { get; set; }
        public List<string> noteNames { get; set; }
        
        public void add_zone(string zone,string note)
        {
            Note note1 = new Note { note = note, text = string.Empty, zone = zone };
            db.Insertable<Note>(note1).ExecuteCommand();
        }

        public void initial_zones()
        {
            zones = new List<string>();
            initial_list();
            foreach(Note note in notes)
            {
                if (!zones.Contains(note.zone))
                    zones.Add(note.zone);
            }
        }
        public VirManager()
        {
            
            initial_db();
            notes = new List<Note>();
            noteNames = new List<string>();
            if (!File.Exists(dbPath))
            {
                db.CodeFirst.InitTables(typeof(Note));
            }
            initial_list();
            initial_zones();
        }
        private void initial_db()
        {
            db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = "data source="+ dbPath,
                DbType = DbType.Sqlite,//设置数据库类型
                IsAutoCloseConnection = true,//自动释放数据务，如果存在事务，在事务结束后释放
                InitKeyType = InitKeyType.Attribute //从实体特性中读取主键自增列信息
            });
            
        }

        public  void initial_list()
        {
            notes.Clear();
            try
            {
                notes.AddRange(db.Queryable<Note>().ToList());
            }
            catch (Exception)
            {
                Console.WriteLine("数据库中没有东西");
            }            
        }

        public bool insert_db(Note note)
        {
            foreach(Note notee in notes)
            {
                if(note.zone.Equals(notee.zone) & note.note.Equals(notee.note))
                {
                    return false;
                }
            }
            try
            {
                db.Insertable(note).ExecuteCommand();
            }
            catch (Exception)
            {
                return false;
            }
            initial_list();
            return true;
        }

        public bool update_zone(string old_zone,string new_zone)
        {
            try
            {
                foreach(Note notee in notes)
                {
                    if (notee.zone == old_zone)
                    {
/*                        db.Deleteable<Note>().Where(it => it.zone == notee.zone & it.note == notee.note).ExecuteCommand();*/
                        notee.zone = new_zone;
                        db.Updateable<Note>(notee).ExecuteCommandAsync();
                    }
                }
               
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            initial_list();
            return true;
        }
        public bool update_text(Note note)
        {
            try
            {
                db.Updateable<Note>(note).Where(it=>it.zone==curZone & it.note==curNote).ExecuteCommand();
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public bool delete_note(Note notee)
        {
            try
            {
                var t5 = db.Deleteable<Note>().Where(it => it.zone == notee.zone & it.note == notee.note).ExecuteCommand();
            }
            catch (Exception e)
            {
                Console.WriteLine(e) ;
            }
            notes.Remove(notee);


            initial_list();
            return true;
        }
        public bool delete_zone_by_name(string areaName)
        {
            try
            {
                var t5 = db.Deleteable<Note>().Where( it=>it.zone == areaName).ExecuteCommand();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            initial_list();
            return true;
        }
        public bool delete_note_by_name(string areaName,string noteName)
        {
            try
            {
                var t5 = db.Deleteable<Note>().Where(it => it.note==noteName & it.zone==areaName).ExecuteCommand();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            initial_list();
            return true;
        }



        public void get_notes()
        {
            try
            {
                noteNames.Clear();
                noteNames.AddRange(db.Queryable<Note>().Where(it => it.zone == curZone).Select(f => f.note).ToList());

            }
            catch (Exception e )
            {
                Console.WriteLine(e);
            }
        }

        public void get_content()
        {
            curCont = db.Queryable<Note>().Where(it => it.zone==curZone & it.note==curNote).Select(f => f.text).First();
        }

        internal void update_note(string curZone, string curNote, string str)
        {
            try
            {
                foreach (Note notee in notes)
                {
                    if (notee.zone == curZone & notee.note== curNote)
                    {
                        notee.note = str;
                        db.Updateable<Note>(notee).ExecuteCommandAsync();
                        break;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }
            initial_list();
        }

        internal void move(string copyZone, string copyNote, string curZone)
        {
            try
            {
                foreach (Note notee in notes)
                {
                    if (notee.zone == copyZone & notee.note == copyNote)
                    {
                        notee.zone = curZone;
                        db.Updateable<Note>(notee).ExecuteCommandAsync();
                        break;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }
            initial_list();
        }
    }
}
