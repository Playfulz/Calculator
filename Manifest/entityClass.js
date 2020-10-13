Class Entity {
  constructor(client, entity) {
    this.client = client;
    this.entity = entity.toLowerCase();
    this.data = new Object();
  }
  
  get entityType() {
    return this.entity;
  } //Entity.entityType will return the entity created.
  
  async start() {
    let data = this.data;
    switch(this.entity) {
      case 'worm':
        data.moves = {
          bite: {
            damage: 2,
          },
          trip: {
            damage: 1,
            delay: 1 //delay 1 move
          },
          slimy_skin: {
            speed: 2 //increase speed +2
          }
        };
        break;
      case 'snake':
        data.atk = 0 //insert default value;
        data.moves = {
          bite: {
            damage: 1,
          },
          trip: {
            damage: 1,
            delay: 1
          },
          teeth_sharpen: {
            increaseAtk():  { data.atk = 2 }
          }
        }
    break;
    }
  }
}

module.exports = Entity;
