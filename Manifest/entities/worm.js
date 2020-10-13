Class WormEntity {
  constructor(client) {
    this.client = client;
    this.data = new Object();
  }
  
  start(user) { //user must be an object with user's stats (atck, hp, etc)
    let data = this.data;
    data.moves = {
      bite(): {
        user.health += -2 //2 is the damage;
      }
      trip(): {
        user.health += -1 //1 is damage
        //idk what delay is in the given scenario
      }
      slimy_skin(): {
        data.speed += 2 //2 is speed points
      }
    }
    return data;
  }
}

module.exports = WormEntity;
