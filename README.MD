<h1>scheduleTelegramBot</h1>
<h2>Overview</h2>
<div>
    <p>scheduleTelegramBot is a bot that returns the university schedule.</p>
    <p>In project was used:</p>
    <ul>
        <li>C#</li>
        <li>Web API</li>
        <li>Telegram.Bot library by RoundRobin</li>
        <li>ORM Entity Framework</li>
        <li>SQL Server</li>
    </ul>
</div>
<div id="functionality">
    <h2>Functionality</h2>
    <p>The bot has 6 commands</p>
    <p><b>/start</b> command -  is the command that will be executed first. The command returns the list of faculties, and the student has to choose his faculty.</p>
    <p><b>/remove</b> command - is the command that simply removes the user from DB.</p>
    <p><b>/schedule</b> command - is the command that returns today's schedule.</p>
    <p><b>/tomorrow</b> command - is the command that returns tomorrow's schedule.</p>
    <p><b>/week</b> command - is the command that returns a weekly schedule.</p>
    <p><b>/subjects</b> command - is the command that returns the list of subjects in button forms, so the user can click the button and get the information about the subject.
        The whole workflow is shown <a href="#workflow">below</a></p>
</div>
<div>
    <h2>How to try</h2>
    <p>To try out the bot, just find him by its username: @scheduleUniversityBot</p>
</div>
<div id="workflow">
<h2>Workflow</h2>
<h3>Register Workflow</h3>
<p>To start working with bot user should call <b>/start</b> command, then the user will have to choose the faculty and the group he is studing in.</p>
<p>This command will add a new user to DB with selected group, faculty and telegram's first name, last name and username. Further this data is used to identify whether the user is registrated and if yes - correct schedule will be returned.</p>
<img src="https://github.com/vlemish/scheduleUniversityBot/blob/master/imgs/RegisterWorkflow.gif" alt="register">
<h3>Getting schedule commands</h3>
<p>As was written <a href="#functionality">above</a> there are three ways to get the schedule. You can get today's, tomorrow's or weekly schedule.</p>
<img src="https://github.com/vlemish/scheduleUniversityBot/blob/master/imgs/GetSchedule.gif" alt="get schedule">
<h3>Subjects command</h3>
<p>Also you can get information about the subjects. To do so, you should call <b>/subjects</b> command, after this you'll have the list of avaliable subjects which are returned in a buttons form, so you can click on a button and get information about the subject.</p>
<img src="https://github.com/vlemish/scheduleUniversityBot/blob/master/imgs/SubjectsCommand.gif" alt="subjects">
<h3>Remove command</h3>
<p>You can remove yourself from Db, to do so you can call <b>/remove</b> command. That also can be usefull if you made in choosing the faculty or the group in registrating.</p>
<img src="https://github.com/vlemish/scheduleUniversityBot/blob/master/imgs/RemoveCommand.gif" alt="remove">
<h3>Wrong command</h3>
<p>If the command isn't known to the bot, bot will send a message, that the command is unknown.</p>
<img src="https://github.com/vlemish/scheduleUniversityBot/blob/master/imgs/WrongCommand.gif" alt="wrong">
</div>
