
namespace TestLavaProject.Core
{
    public class ShootingStateLogic : GameStateLogic
    {
        public override GameState State => GameState.Shooting;

        public ShootingStateLogic(Player player, Enemy enemy) : base(player, enemy)
        {
        }

        public override void Start()
        {
            _player.CanShoot = true;
            _isReadyForChanging = false;
        }

        public override void Update()
        {
            throw new System.NotImplementedException();
        }

        public override void End()
        {
            _player.CanShoot = false;
        }
    }
}