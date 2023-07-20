using Microsoft.AspNetCore.Components;
using NET106_Demo_BlazorServer.IServices;
using NET106_Demo_Shared;

namespace NET106_Demo_BlazorServer.Pages
{
    public class ListFootballPlayersBase : ComponentBase
    {
        [Inject]
        public IFootballPlayerService FootballPlayerService { get; set; }

        public IEnumerable<FootballPlayer> FootballPlayers { get; set; }

        protected override async Task OnInitializedAsync()
        {
            FootballPlayers = (await FootballPlayerService.GetFootballPlayers()).ToList();
        }
    }
}
