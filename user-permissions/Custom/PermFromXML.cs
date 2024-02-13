using System.Runtime.Serialization;
using System.Xml;
using IO.Swagger.Models;
using NuGet.Protocol;

namespace user_permissions.Custom
{
    public class PermFromXML
    {  
        List<UserPermissions> permissions = new List<UserPermissions>();//all permission model 
        List<UserRole> roles = new List<UserRole>();//model role with name lower()

        public PermFromXML(string file) {
            var doc = new XmlDocument();
            doc.Load(file);
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
                                                if (roles.Count == 0)
                                                {
                                                    foreach (XmlElement n5 in n4.ChildNodes)
                                                    {
                                                        string ptxt = n5.InnerText;
                                                        if (ptxt.Length > 1)
                                                        {
                                                            if (ptxt == ptxt.ToUpper())
                                                            {
                                                                UserRole rol = new();
                                                                rol.Id = (roles.Count+1).ToString();
                                                                rol.UserLogin = ptxt.ToLower();
                                                                rol._UserRole = ptxt;
                                                                roles.Add(rol);

                                                                UserPermissions perm = new();
                                                                perm.UserRole = ptxt;
                                                                perm.Permissions = new ();
                                                                permissions.Add(perm);
                                                            }
                                                        }
                                                    }
                                                }

                                                //permissions
                                                if (n4.ChildNodes.Count > 8)
                                                {
                                                    string ptxt = n4.ChildNodes.Item(1).InnerText;
                                                    if (!string.IsNullOrEmpty(ptxt)) {
                                                        if (ptxt == ptxt.ToUpper())
                                                        {
                                                            //разбор прав
                                                            //2-6                                      
                                                            if (!string.IsNullOrEmpty(n4.ChildNodes.Item(3).InnerText))
                                                            {
                                                                permissions.FirstOrDefault(p => p.UserRole == roles[0]._UserRole).Permissions.Add(ptxt);
                                                            }
                                                            if (!string.IsNullOrEmpty(n4.ChildNodes.Item(4).InnerText))
                                                            {
                                                                permissions.FirstOrDefault(p => p.UserRole == roles[1]._UserRole).Permissions.Add(ptxt);
                                                            }
                                                            if (!string.IsNullOrEmpty(n4.ChildNodes.Item(5).InnerText))
                                                            {
                                                                permissions.FirstOrDefault(p => p.UserRole == roles[2]._UserRole).Permissions.Add(ptxt);
                                                            }
                                                            if (!string.IsNullOrEmpty(n4.ChildNodes.Item(6).InnerText))
                                                            {
                                                                permissions.FirstOrDefault(p => p.UserRole == roles[3]._UserRole).Permissions.Add(ptxt);
                                                            }
                                                            if (!string.IsNullOrEmpty(n4.ChildNodes.Item(7).InnerText))
                                                            {
                                                                permissions.FirstOrDefault(p => p.UserRole == roles[4]._UserRole).Permissions.Add(ptxt);
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
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(permissions.ToJson(), Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\Permissions\\roles.json")))
            {
                outputFile.Write(roles.ToJson());
            }
        }
    }
}
