namespace WebAPIMacoratti.Models
{
    public class Repository : IRepository
    {
        private Dictionary<int, Reserva> items;
        public Repository() { 
        
            items = new Dictionary<int, Reserva>();
            new List<Reserva> {
             new Reserva {reservaId=1, nome = "Macoratti", inicioLocacao = "São Paulo", fimLocacao = "Lins" },
             new Reserva {reservaId=2, nome = "Paulo", inicioLocacao = "Campinas", fimLocacao="São Paulo" },
             new Reserva {reservaId=3, nome = "Maria", inicioLocacao = "Jundiaí", fimLocacao="Campinas" }
             }.ForEach(r => AddReserva(r));
        }
        public Reserva this[int id] => items.ContainsKey(id) ? items[id] : null;

        public IEnumerable<Reserva> Reservas => items.Values;

        public Reserva AddReserva(Reserva reserva)
        {
            if (reserva.reservaId == 0)
            {
                int key = items.Count;
                while (items.ContainsKey(key)) { key++; };
                reserva.reservaId = key;
            }
            items[reserva.reservaId] = reserva;
            return reserva;
        }
        public void DeleteReserva(int id)
        {
            items.Remove(id);
        }
        public Reserva UpdateReserva(Reserva reserva)
        {
            AddReserva(reserva);
            return reserva;
        }


    }
}
