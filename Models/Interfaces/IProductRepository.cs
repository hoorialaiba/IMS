namespace IMSIdentity.Models.Interfaces
{
    public interface IProductRepository
    {
        public List<Product> GetAll();
        public Product GetById(string barcode);

        public void Add(Product product);

        public void Update(Product product);

        public void Delete(string barcode);
    }
}
