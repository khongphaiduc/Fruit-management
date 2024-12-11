using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Fruits
{
    public  class Validate
    {


       public String viethoachucaidau(String name )
        {
            // trong C# không thể chuyển đổi 1 ký tự , từ thường sang hoa nếu gốc của nó là String , nên cần phải chuyển sang mảng ký tự 
            char[] charname = name.ToCharArray();

            bool foundSpaceWhile = true;

            for( int i = 0;i<charname.Length;i++)
            {
                if (char.IsWhiteSpace(charname[i]))
                {
                    foundSpaceWhile = true;
                }
                else
                {
                    if(foundSpaceWhile)
                    {
                        charname[i] = char.ToUpper(charname[i]);
                        foundSpaceWhile = false;       
                    }
                    foundSpaceWhile = false;
                }
            }
             return new string(charname);
        }

        public bool checkName(String name)
        {
            return Regex.IsMatch(name, "[a-z A-Z]");
        }

        public String inputName()
        {
            while(true)
            {
            String name = Console.ReadLine().Trim();
            if(!checkName(name)) {
                    Console.WriteLine("Tên không chứa các ký tự đặc biệt hoặc chữ số");
                    continue;
            }
              return viethoachucaidau(name);

            }
        }


        public int  checkID(List<Fruits> list )
        {
            while(true)
            {
                try
                {
                 int id = int.Parse(Console.ReadLine());
                    if (id < 0) {
                        Console.WriteLine("ID không tồn tại ");
                        continue;
                    }

                    else if (id > list[list.Count-1].ID)
                    {
                        Console.WriteLine("ID không tồn tại ");
                        continue;
                    }
                    return id;
                }
                catch(Exception e) {
                    Console.WriteLine("ID không tồn tại ");
                    continue;
                }
            }
        }
        public int purchasequantity()
        {
            while (true)
            {
                try
                {
                    Console.Write("Nhập Số lượng cần mua :");
                    int numer = int.Parse(Console.ReadLine());
                    if(numer < 0) {
                        Console.WriteLine("Số lượng mua không hợp lệ");
                        continue;
                    }
                    return numer;
                }
                catch (Exception)
                {
                    Console.WriteLine("Số lượng mua không hợp lệ");
                    continue;
                }
            }
        }


        public String inputOrgin() {
            while(true)
            {
                Console.Write("Nhập Tên Quốc Gia :");
                String orgin = Console.ReadLine();
                if(!checkName(orgin)) {
                    Console.WriteLine("Tên không chứa các ký tự đặc biệt hoặc chữ số");
                    continue;
                }
                 return orgin;
            }

        }


        public double inputDouble()
        {
           double number;
            while (true)
            {
                try
                {
                    number = double.Parse(Console.ReadLine());
                    if (number < 0)
                    {
                        Console.WriteLine("Number >0");
                        continue;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Phập sai vui lòng chỉ nhập số nguyên ");
                    continue;
                }

                return number;
            }
        }

        public int inputNumer()
        {
            int number;
            while (true){
                try
                {
                 number = int.Parse(Console.ReadLine());
                    if(number<0)
                    {
                        Console.WriteLine("Number >0");
                        continue;
                    }
                }
                catch (Exception e) { 
                  Console.WriteLine("Phập sai vui lòng chỉ nhập số nguyên ");
                    continue;
                }   

                 return number;
            }


        }



        public int inputOPTION()
        {
            while (true)
            {
                try
                {
                   int op = int.Parse(Console.ReadLine());
                    if(op<0||op>4)
                    {
                        Console.WriteLine("Option bạn chọn không tồn tại hoặc đang trong quá trình update,xin vui lòng chọn lại !");
                        continue;
                    }
                    return op;
                }
                catch (Exception s)
                {
                    Console.WriteLine("Option bạn chọn không tồn tại hoặc đang trong quá trình update,xin vui lòng chọn lại !");
                    continue;
                }
            }

        }



    }

    }
