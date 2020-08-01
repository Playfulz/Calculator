const Discord = require('discord.js');
const client = new Discord.Client();
const { TOKEN } = require('./config.json');

client.on('message', async message => {
	if (message.content.startsWith('jtest')) {
		message.channel.send('hullo');
	}
});

client.login(TOKEN);

