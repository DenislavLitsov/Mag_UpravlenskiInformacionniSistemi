namespace UpravlenskiInformacionniSistemi.Web.ViewModels.Common
{
    public class IntStringWrapper
    {
        public IntStringWrapper(string name, int id)
        {
            this.Name = name;
            this.Id = id;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
