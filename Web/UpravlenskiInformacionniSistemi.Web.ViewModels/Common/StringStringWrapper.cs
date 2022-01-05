namespace UpravlenskiInformacionniSistemi.Web.ViewModels.Common
{
    public class StringStringWrapper
    {
        public StringStringWrapper()
        {
        }

        public StringStringWrapper(string name, string id)
        {
            this.Name = name;
            this.Id = id;
        }

        public string Id { get; set; }

        public string Name { get; set; }
    }
}
