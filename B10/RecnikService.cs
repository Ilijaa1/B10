using B10.Data;
using B10.Model;

namespace B10
{
    public class RecnikService
    {
        private readonly RecnikDbContext _recnikDbContext;

        public RecnikService(RecnikDbContext recnikDbContext)
        {
            _recnikDbContext = recnikDbContext;
        }

        public void DodajPrevod(Prevod prevod)
        {
            _recnikDbContext.Prevodi.Add(prevod);
            _recnikDbContext.SaveChanges();
        }

        public Prevod PrevediSrpski(string srpskaRec)
        {
            Prevod prevod = _recnikDbContext.Prevodi.FirstOrDefault(p => p.Srpski == srpskaRec);

            return prevod;
        }

        public Prevod PrevediEngleski(string engleskaRec)
        {
            Prevod prevod = _recnikDbContext.Prevodi.FirstOrDefault(p => p.Engleski == engleskaRec);

            return prevod;
        }

    }
}
