// MIS 3033 004 Exercise
// Jack Herdejurgen 113436899

// add xinglong.ju@ou.edu as the collaborator on GitHub
// 

//Add a new student
//Enter the ID: 
//Enter the name: 
//Enter the grade:

using MIS3033_004_EX3;
using StuDBConnect connect = new StuDBConnect();

string userinput = "";
List<string> valid = new List<string>();
for(int i=1; i < 8; i++)
{
    valid.Add($"{i}");
}


do
{
    Console.WriteLine("****************************************************\r\n 1. Add a new student's information\r\n 2. Show all the students' information\r\n 3. Show one student's information for an given Student ID\r\n 4. Edit one student's information for an given Student ID\r\n 5. Delete one student's information for an given Student ID\r\n 6. Show the student's information with highest grade\r\n 7. Show the average grade of all the students\r\n Press other keys to exit\r\n****************************************************");
    Console.Write("Enter your option: ");
    userinput = Console.ReadLine();
    if (userinput == "1")
    {
        Console.WriteLine("Add a new student");
        Console.Write("Enter the ID: ");
        string ID = Console.ReadLine();
        Console.Write("Enter the name: ");
        string name = Console.ReadLine();
        Console.Write("Enter the grade: ");
        double grade = Convert.ToDouble(Console.ReadLine());
        Student stu = new Student();
        stu.ID = ID;
        stu.name = name;
        stu.grade = grade;
        stu.letterGrade = stu.GetLetterGrade();
        connect.Add(stu);
        connect.SaveChanges();
    }
    else if (userinput == "2")
    {
        Console.WriteLine("Show all student information");
        foreach (Student stu in connect.students.ToList())
        {
            Console.WriteLine(stu);
        }

    }
    else if (userinput == "3")
    {
        Console.Write("Show student by ID: ");
        string id = Console.ReadLine();
        foreach (Student stu in connect.students.ToList())
        {
            if(stu.ID == id)
            {
                Console.WriteLine(stu);
            }
        }
    }
    else if (userinput == "4")
    {
        Console.Write("Edit one student by ID: ");
        string id = Console.ReadLine();
        Student stu = connect.students.Where(x=>x.ID==id).FirstOrDefault();
        Console.WriteLine("Current Info: ");
        Console.WriteLine(stu);
        Console.Write("Enter the new name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Enter the new grade: ");
        double grade = Convert.ToDouble(Console.ReadLine());
        stu.name = name;
        stu.grade = grade;
        stu.letterGrade = stu.GetLetterGrade();
        connect.Update(stu);
        connect.SaveChanges();
    }
    else if (userinput == "5")
    {
        Console.Write("Delete student by ID: ");
        string id = Console.ReadLine();
        Student stu = connect.students.Where(x => x.ID == id).FirstOrDefault();
        Console.WriteLine("Current Data:");
        Console.WriteLine(stu);
        connect.Remove(stu);
        Console.WriteLine("Data Deleted");
        connect.SaveChanges();
    }
    else if (userinput == "6")
    {
        Student highest = new Student();
        Console.WriteLine("Show student with highest grade:");
        foreach (Student stu in connect.students.ToList())
        {
            if (stu.grade > highest.grade)
            {
                highest = stu;
            }
        }
        Console.WriteLine(highest);
    }
    else if (userinput == "7")
    {
        double sum = 0;
        int counter = 0;
        
        foreach (Student stu in connect.students.ToList())
        {
            sum += stu.grade;
            counter++;
        }
        double average = sum / counter;
        Console.WriteLine($"The average grade is: {average:F2}");
    }
}
while (valid.Contains(userinput));
