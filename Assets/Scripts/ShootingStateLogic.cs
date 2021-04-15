
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
            _player.PlayerShooting.CanShoot = true;
            _isReadyForChanging = false;
        }

        public override void Update()
        {
        }

        public override void End()
        {
            _player.PlayerShooting.CanShoot = false;
        }
    }
}