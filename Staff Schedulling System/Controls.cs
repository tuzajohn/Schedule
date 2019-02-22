using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;

using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Staff_Schedulling_System
{
    public class Controls
    {
        public string Key = "h$r&!@_<";
        public string UserId { get; set; }
        public const int HOURS = 24;        
        public Controls() { }
        public string SetShift(string staffId, string wardId)
        {
            var weekList = new List<string> { "MONDAY", "TUESDAY", "WEDNESDAY", "THURSDAY", "FRIDAY", "SATURDAY", "SUNDAY" };
            var days = new List<int>();
            for (int i = 0; i < weekList.Count; i++)
            {
                int j = weekList.IndexOf(DateTime.Now.AddDays(i).DayOfWeek.ToString().ToUpper());
                days.Add(j + 1);
            }
            
            StaffSchedullingDbEntities3 dbEntities = new StaffSchedullingDbEntities3();
            var setting = dbEntities.Settings.Where(s => s.WardId == wardId).FirstOrDefault();
            var lengthOfShift = HOURS / setting.NumberOfShiftaDayInWard;//start time of each shift
            var contactHours = lengthOfShift * 5;//total hours that a staff needs to be working

            var hoursList = new List<int>();//list of all starting times of a shift
            for (int i = 0; i < HOURS; i += lengthOfShift)
                hoursList.Add(i);

            //gets total count of staff in a ward
            var staffCounter = dbEntities.Staffs.Where(staff => staff.StaffWards.FirstOrDefault(sw => sw.StaffID == staff.Id).WardId == wardId);
            if (staffCounter.Count() < setting.NumberOfStaffInWard)
            {
                Random random = new Random();
                var index = 0;
                foreach (var day in days)
                {
                    index++;
                    var shift = new Shift();
                    var date = DateTime.Now;
                    var ShiftsForTheDayInWard = dbEntities.Shifts.Where(s => s.WardId == wardId && s.Day == index).ToList();
                    var start = hoursList[random.Next(0, hoursList.Count)];//get a random start time
                    if (ShiftsForTheDayInWard.Count == 0)
                    {
                        shift = IndividualShift(staffId, wardId, dbEntities, lengthOfShift, day, date, start);
                        dbEntities.Shifts.Add(shift);
                        dbEntities.SaveChanges();
                        contactHours -= lengthOfShift;
                        //ensures if the contact hours are depleted therefore free days are set.
                        if (contactHours == 0)
                            break;

                        continue;
                    }

                    List<TimeSpan> registeredTimes = (from obj in ShiftsForTheDayInWard
                                                      select obj.StartTime).ToList();

                    var result = hoursList.Where(p => !registeredTimes.Any(p2 => TimeSpan.FromHours(p) == p2)).ToList();
                    if (result.Count() != 0)//getting a slot that isnt occupied within the day
                        shift = IndividualShift(staffId, wardId, dbEntities, lengthOfShift,
                            day, date, result[random.Next(0, result.Count)]);
                    else
                    {//in case all slotes are already occupied, then get the time with the least number of staff!
                        var ordered = ShiftsForTheDayInWard
                        .GroupBy(x => x.StartTime)
                        .Select(group => new { group.Key, Count = group.Count() })
                        .OrderBy(x => x.Count);

                        var minOccurrenceCount = ordered.First().Count;

                        var leastOccurredTime = ordered
                            .TakeWhile(x => x.Count == minOccurrenceCount)
                            .Select(x => x.Key).ToList();
                        shift = IndividualShift(staffId, wardId, dbEntities, lengthOfShift,
                            day, date, Convert.ToInt32(leastOccurredTime[random.Next(0, leastOccurredTime.Count)].Hours));
                    }

                    dbEntities.Shifts.Add(shift);
                    dbEntities.SaveChanges();

                    contactHours -= lengthOfShift;
                    //ensures if the contact hours are depleted therefore free days are set.
                    if (contactHours == 0)
                        break;
                }
            }
            else
            {
                //warning that the ward got enough already
            }

            return "";
        }

        private static Shift IndividualShift(string staffId, string wardId, StaffSchedullingDbEntities3 dbEntities, int lengthOfShift, int day, DateTime date, int start)
        {
            //var today = DateTime.Now.DayOfWeek.ToString().ToUpper();
            Shift shift = new Shift
            {
                Id = $"Shift/{date.Day}/{date.Year}/{date.Month}/{(dbEntities.Shifts.Count() == 0 ? 1 : (dbEntities.Shifts.Count() + 1))}",
                Day = day,
                StaffId = staffId,
                WardId = wardId,
                StartTime = TimeSpan.FromHours(start),
                EndTime = (start + lengthOfShift) == 24 ? TimeSpan.FromSeconds(0) : TimeSpan.FromHours(start + lengthOfShift),
                Date = date,
                Staff = dbEntities.Staffs.Where(s=>s.Id == staffId).FirstOrDefault(),
                Ward = dbEntities.Wards.Where(w=>w.Id == wardId).FirstOrDefault()
            };
            return shift;
        }

        public void ReSchedule(int numberOfStaffInWard, int numberHoursInShift, string wardId)
        {
            
        }

        TimeSpan GetTime(List<int> hours)
        {            
            return TimeSpan.FromHours(hours.FirstOrDefault());
        }

        public void WriteToPdf(DataTable table, string path, string header, string extractedByName)
        {
            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
            Document document = new Document();
            document.SetPageSize(PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);

            document.Open();

            BaseFont baseFont = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntHead = new Font(baseFont, 16, 1, BaseColor.GRAY);
            Paragraph pHeading = new Paragraph
            {
                Alignment = Element.ALIGN_LEFT
            };
            pHeading.Add(new Chunk(header.ToUpper(), fntHead));
            document.Add(pHeading);


            //Author
            Paragraph prAuthor = new Paragraph();
            BaseFont bsfAuthorFont = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntAuthor = new Font(baseFont, 8, 2, BaseColor.GRAY);
            prAuthor.Alignment = Element.ALIGN_RIGHT;
            prAuthor.Add(new Chunk("Extracted by: " + extractedByName, fntAuthor));
            prAuthor.Add(new Chunk("\nOn " + DateTime.Now.ToLongDateString(), fntAuthor));
            document.Add(prAuthor);

            //Line Separation
            Paragraph p = new Paragraph(
                new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_MIDDLE, 0.0F)));
            document.Add(p);

            //line break
            document.Add(new Chunk("\n", fntHead));

            //write to table
            PdfPTable pTable = new PdfPTable(table.Columns.Count);
            BaseFont bsfColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntColumnHeader = new Font(baseFont, 10, 1, BaseColor.BLACK);

            //table header
            for (int i = 0; i < table.Columns.Count; i++)
            {
                PdfPCell pCell = new PdfPCell();
                pCell.BackgroundColor = BaseColor.WHITE;
                pCell.AddElement(new Chunk(table.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                pTable.AddCell(pCell);
            }
            //table data
            for (int i = 0; i < table.Rows.Count; i++)
            {
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    pTable.AddCell(table.Rows[i][j].ToString());
                }
            }

            document.Add(pTable);
            document.Close();
            writer.Close();
            fs.Close();
        }
        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
    }
    public class Person
    {
        public string StaffId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Ward { get; set; }
        public string DOB { get; set; }
    }

}
