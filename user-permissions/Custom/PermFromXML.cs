using IO.Swagger.Models;
using NuGet.Protocol;
using System.Xml;
using System.Text.Json;
using Newtonsoft.Json;

public class Departament
{
    public string departmentId { get; set; }
    public string code { get; set; }
    public string name { get; set; }
    public string manager { get; set; }

}
public class Person
{
    public string nickName { get; set; }
    public Departament department { get; set; }
    public string name { get; set; }
    public string jobPosition { get; set; }
    public string city { get; set; }
    public string state { get; set; }
}

namespace user_permissions.Custom
{
    public class PermFromXML
    {
        public List<UserPermissions> permissions = new List<UserPermissions>();//all permission model 
        public List<UserRole> roles = new List<UserRole>();//model role with name lower()

        public PermFromXML()
        {
            string missions = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Permissions\\permission_table.html";
            string pers = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Permissions\\person.json";

            List<string> allroles = new List<string>();

            var doc = new XmlDocument();
            doc.Load(missions);
            //read roles and permissions
            foreach (XmlElement n0 in doc.ChildNodes)
            {
                foreach (XmlElement n1 in n0.ChildNodes)
                {
                    if (n1.Name == "div")
                    {
                        foreach (XmlElement n2 in n1.ChildNodes)
                        {
                            if (n2.Name == "table")
                            {
                                foreach (XmlElement n3 in n2.ChildNodes)
                                {
                                    if (n3.Name == "tbody")
                                    {
                                        foreach (XmlElement n4 in n3.ChildNodes)
                                        {
                                            if (n4.Name == "tr")
                                            {
                                                //roles
                                                if (allroles.Count == 0)
                                                {
                                                    foreach (XmlElement n5 in n4.ChildNodes)
                                                    {
                                                        string ptxt = n5.InnerText;
                                                        if (ptxt.Length > 1)
                                                        {
                                                            if (ptxt == ptxt.ToUpper())
                                                            {
                                                                /*UserRole rol = new UserRole();
                                                                rol.Id = (roles.Count + 1).ToString();
                                                                rol.UserLogin = ptxt.ToLower();
                                                                rol._UserRole = ptxt.ToLower();
                                                                roles.Add(rol);*/
                                                                allroles.Add(ptxt.ToLower());

                                                                UserPermissions perm = new UserPermissions();
                                                                perm.UserRole = ptxt.ToLower();
                                                                perm.Permissions = new List<string>();
                                                                permissions.Add(perm);
                                                            }
                                                        }
                                                    }
                                                }

                                                //permissions
                                                if (n4.ChildNodes.Count > 8)
                                                {
                                                    string ptxt = n4.ChildNodes.Item(1).InnerText;
                                                    if (!string.IsNullOrEmpty(ptxt))
                                                    {
                                                        if (ptxt == ptxt.ToUpper())
                                                        {
                                                            //разбор прав
                                                            //2-6                                      
                                                            if (!string.IsNullOrEmpty(n4.ChildNodes.Item(3).InnerText))
                                                            {
                                                                permissions[0].Permissions.Add(ptxt);
                                                            }
                                                            if (!string.IsNullOrEmpty(n4.ChildNodes.Item(4).InnerText))
                                                            {
                                                                permissions[1].Permissions.Add(ptxt);
                                                            }
                                                            if (!string.IsNullOrEmpty(n4.ChildNodes.Item(5).InnerText))
                                                            {
                                                                permissions[2].Permissions.Add(ptxt);
                                                            }
                                                            if (!string.IsNullOrEmpty(n4.ChildNodes.Item(6).InnerText))
                                                            {
                                                                permissions[3].Permissions.Add(ptxt);
                                                            }
                                                            if (!string.IsNullOrEmpty(n4.ChildNodes.Item(7).InnerText))
                                                            {
                                                                permissions[4].Permissions.Add(ptxt);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
            }

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(permissions.ToJson(), Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Permissions\\permissions.json")))
            {
                outputFile.Write(permissions.ToJson());
            }
            /*using (StreamWriter outputFile = new StreamWriter(Path.Combine(permissions.ToJson(), Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Permissions\\roles.json")))
            {
                outputFile.Write(roles.ToJson());
            }*/

            //person
            List<Person> persons = new List<Person>();
            using (StreamReader reader = new StreamReader(pers))
            {
                string json = reader.ReadToEnd();
                persons = JsonConvert.DeserializeObject<List<Person>>(json);
            }
            
            roles.Add(new UserRole() { Id = "3000", UserLogin = "djaz", _UserRole = "superuser" });
            roles.Add(new UserRole() { Id = "3001", UserLogin = "kazurus", _UserRole = "manager" });
            roles.Add(new UserRole() { Id = "3002", UserLogin = "nomad", _UserRole = "employee" });

            int i = 1;

            List<string> ex = new List<string>{"djaz", "kazurus", "nomad"};
            foreach (Person per in persons) 
            {
                if (!ex.Contains(per.nickName.ToLower()))
                {
                    UserRole role = new UserRole();
                    role.Id = i.ToString();
                    role.UserLogin = per.nickName.ToLower();
                    role._UserRole = allroles[new Random().Next(0, 4)];
                    roles.Add(role);
                    i++;
                }
            }

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(permissions.ToJson(), Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Permissions\\roles.json")))
            {
                outputFile.Write(roles.ToJson());
            }

        }
    }
}
