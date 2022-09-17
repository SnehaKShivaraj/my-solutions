public class Solution {
    public int MatchPlayersAndTrainers(int[] players, int[] trainers) {
       int match = 0;
        var playersList = players.ToList(); 
       var trainersList = trainers.ToList();  
        playersList.Sort();
        trainersList.Sort();
        foreach(int player in playersList)
        {
            foreach(int trainer in trainersList)
            {
                if(player <= trainer)
                {
                    match++;
                    trainersList.Remove(trainer);
                    break;
                }
            }
        }
        
        return match;
    }
}