using OtoYedekParca.Entity;

namespace OtoYedekParca.ViewModels
{
    public class TanimlamaViewModel
    {
        public List<UrunGrup> urunGruplari { get; set; }
        public List<Marka> markalar { get; set; }
        public List<Model> modeller { get; set; }
        public List<Tip> tipler { get; set; }
        public List<Motor> motorlar { get; set; }
        
    }
}