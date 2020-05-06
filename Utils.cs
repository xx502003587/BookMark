using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Collections;
using System.Text.RegularExpressions;

namespace BookMark {

    struct BookMarkInfo {
        public BookMarkInfo(int id, string urlName, string urlValue, 
                            int posX, int posY) {
            this.id = id;
            this.urlName = urlName;
            this.urlValue = urlValue;
            this.posX = posX;
            this.posY = posY;
        }
        public int id;
        public string urlName;
        public string urlValue;
        public int posX;
        public int posY;
        public string String() {
            return "id=" + this.id + "\turlName=" + this.urlName +
                            "\turlValue=" + this.urlValue +
                            "\tposX=" + this.posX + "\tposY=" + this.posY;
        }
        public string Value() {
            return this.id +"\t" + this.urlName +"\t" +  this.urlValue +"\t" + 
                   this.posX +"\t" + this.posY;
        }
    }

    class Utils {
        private int BTN_WIDTH = 150;
        private int BTN_HEIGHT = 40;
        private int START_X = 20;
        private int START_Y = 40;
        private int INTERVAL_X = 40;
        private int INTERVAL_Y = 20;

        private static Utils Instance;
        private string DataFilePath;
        private string SettingsFilePath;
        //private int CurrentNumber;
        private List<string> FileNames;
        private string CurrentType;
        private Dictionary<string, List<BookMarkInfo>> Books;
        private string path;

        private Utils() {
            this.path = "data/";
            if (!Directory.Exists(this.path)) { //如果不存在就创建file文件夹
                Directory.CreateDirectory(this.path);
            }
            this.DataFilePath = "default.sav";
            this.SettingsFilePath = this.path + "settings.sav";
            this.CurrentType = "default";
            //this.CurrentNumber = 0;
            this.FileNames = new List<string>();
            this.Books = new Dictionary<string, List<BookMarkInfo>>();
            ReadDataFromFile();
        }
        //public int number {
        //    get { return this.CurrentNumber; }
        //    set { this.CurrentNumber = value; }
        //}
        public Dictionary<string, List<BookMarkInfo>> books {
            get { return this.Books; }
        }
        public List<string> files {
            get { return this.FileNames; }
        }
        public string type {
            get { return this.CurrentType; }
            set { this.CurrentType = value; }
        }
        public int width {
            get { return this.BTN_WIDTH; }
        }
        public int height {
            get { return this.BTN_HEIGHT; }
        }

        public static Utils GetInstance() {
            if (Instance == null) {
                Instance = new Utils();
            }
            return Instance;
        }

        public void ReadDataFromFile() {
            // 1. 如果settings文件不存在，则创建，并写入默认文件 default.sav
            if (!File.Exists(this.SettingsFilePath)) {
                var sw = File.CreateText(this.SettingsFilePath);
                sw.WriteLine(this.DataFilePath);
                this.FileNames.Add(this.DataFilePath);
                sw.Close();
            }
            // 如果存在，则读取其中的文件名称，加入到FileNames中
            else {
                StreamReader tsr = new StreamReader(this.SettingsFilePath, Encoding.UTF8);
                String name;
                while ((name = tsr.ReadLine()) != null) {
                    this.FileNames.Add(name.Trim());
                }
                tsr.Close();
            }
            // 2. 读取setting中包含的文件
            // 如果default.sav文件不存在则需要创建，因为这是默认的文件
            if (!File.Exists(this.path + this.DataFilePath)) {
                File.Create(this.path + this.DataFilePath).Dispose();
            }
            // 对所有的文件进行读取，存入到books对应的key中去
            for (int i = 0; i < this.FileNames.Count(); ++i) {
                StreamReader sr = new StreamReader(this.path + this.FileNames[i], Encoding.UTF8);
                String line;
                var bookList = new List<BookMarkInfo>();
                while ((line = sr.ReadLine()) != null) {
                    BookMarkInfo bookMarkInfo = new BookMarkInfo();
                    string[] arr = line.Split('\t');
                    int.TryParse(arr[0], out bookMarkInfo.id);
                    bookMarkInfo.urlName = arr[1];
                    bookMarkInfo.urlValue = arr[2];
                    int.TryParse(arr[3], out bookMarkInfo.posX);
                    int.TryParse(arr[4], out bookMarkInfo.posY);
                    // TODO
                    bookList.Add(bookMarkInfo);
                }
                this.books.Add(this.FileNames[i].Split('.')[0], bookList);
                sr.Close();
            }
            Console.WriteLine("DEBUG");
        }

        /// <summary>
        ///  每次添加一个新的标签后，将标签的数据写入文件
        /// </summary>
        /// <param name="book"></param>
        public void AppendBookMarkToFile(ref BookMarkInfo book) {
            var fileName = this.path + this.CurrentType + ".sav";
            FileStream fs = new FileStream(fileName, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(book.Value());
            sw.Close();
            fs.Close();
        }

        /// <summary>
        ///  添加新书签时，新增BookMark，添加到List中，并更新到文件中
        /// </summary>
        /// <param name="urlName">网站名称</param>
        /// <param name="urlValue">网站地址</param>
        /// <param name="newId">BookMark的ID</param>
        /// <param name="newPosX">按钮在界面上的X坐标</param>
        /// <param name="NewPosY">按钮在界面上的Y坐标</param>
        /// <returns></returns>
        public bool AddBookMark(string urlName, string urlValue, out int newId, out int newPosX, out int NewPosY) {
            BookMarkInfo book = new BookMarkInfo();
            int count = GetCurrentBooksCount();
            book.id = count;
            book.urlName = urlName;
            book.urlValue = urlValue;
            ComputeNextPosition(count, out book.posX, out book.posY);
            if (!this.books.ContainsKey(this.CurrentType)) {
                var bookList = new List<BookMarkInfo>();
                bookList.Add(book);
                this.books.Add(this.CurrentType, bookList);
            } else {
                this.books[this.CurrentType].Add(book);
            }
            
            //this.CurrentNumber += 1;

            AppendBookMarkToFile(ref book);
            newId = book.id;
            newPosX = book.posX;
            NewPosY = book.posY;
            return true;
        }

        /// <summary>
        ///  计算下一个按钮所在的坐标
        /// </summary>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        public void ComputeNextPosition(int count, out int posX, out int posY) {
            int rows = count / 4;
            int cols = count % 4;
            posX = this.START_X + cols * (this.BTN_WIDTH + this.INTERVAL_X);
            posY = this.START_Y + rows * (this.BTN_HEIGHT + this.INTERVAL_Y);
        }

        /// <summary>
        ///  当用户进行修改之后，判断修改前后内容是否发生变化
        /// </summary>
        /// <param name="oldName"></param>
        /// <param name="oldValue"></param>
        /// <param name="newName"></param>
        /// <param name="newValue"></param>
        /// <returns>true——发生变化，false——未发生变化</returns>
        public bool IsTextModified(string oldName, string oldValue,
                                   string newName, string newValue) {
            if (oldName.Trim() == newName.Trim() && 
                oldValue.Trim() == newValue.Trim()) {
                return false;
            }
            return true;
        }

        public void RemoveBookMarkById(int id) {
            var books = this.books[this.CurrentType];
            foreach (var book in books) {
                if (book.id == id) {
                    books.Remove(book);
                    return;
                }
            }
        }

        /// <summary>
        ///  当更新书签内容或者删除书签时，根据书签所对应的type进行文本内容的更新
        /// </summary>
        public void WriteDataToFileByType() {
            var books = this.books[this.CurrentType];
            FileStream fs = new FileStream(this.path + this.CurrentType+".sav", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);

            foreach (var book in books) {
                sw.WriteLine(book.Value());
            }
            sw.Close();
            fs.Close();
        }

        public void AddType(string typeName) {
            // 1. 修改当前的类型名称
            this.CurrentType = typeName;
            var typeFileName = typeName + ".sav";

            // 2. 将类型名称写入到setting文件中
            AppendTypeToFile(typeFileName);

            // 3. 将类型名称添加到文件名称列表中
            this.FileNames.Add(typeFileName);

            // 4. 将新的类别加入到books变量中
            var bookList = new List<BookMarkInfo>();
            this.Books.Add(typeName, bookList);

            // 5. 根据类型名称创建一个文件
            File.Create(this.path + typeFileName).Dispose();
        }

        public void AppendTypeToFile(string typeFileName) {
            FileStream fs = new FileStream(this.SettingsFilePath, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(typeFileName);
            sw.Close();
            fs.Close();
        }

        public int GetCurrentBooksCount() {
            return this.Books[this.CurrentType].Count();
        }
        public int GetCurrentBooksLastId() {
            int count = GetCurrentBooksCount();
            return this.Books[this.CurrentType][count-1].id;
        }

        /// <summary>
        ///  当在界面上删除一个按钮时
        ///  1. 对该类别下的书签id进行调整为从0开始递增，否则会造成后续绘制新按钮的错位
        ///  2. 对所有按钮的坐标进行重新计算
        /// </summary>
        public void ReGenerateBooksIdAndPos() {
            var books = this.Books[this.CurrentType];
            List<BookMarkInfo> tbooks = new List<BookMarkInfo>();
            int count = books.Count();
            for (int i = 0; i < count; i++) {
                var tbook = books[i];
                tbook.id = i;
                ComputeNextPosition(i, out tbook.posX, out tbook.posY);
                tbooks.Add(tbook);
            }
            this.Books[this.CurrentType] = tbooks;
        }
    }
}
