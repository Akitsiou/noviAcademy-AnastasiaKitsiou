public class Player {
	public int Id { get; }
	public string Name { get; set; }
	public int Score { get; private set; }

	public Player(int id; string name; int score){
			Id = id;
			Name = name;
			Score = score;
		}
}