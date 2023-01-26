<div id="header" align="center">
  <h1>UWM Diagram</h1>
</div>
    <br/>
<div id="header" align="center">
  <img src="https://user-images.githubusercontent.com/48823161/209620578-40e4db12-b1fd-40ab-89fe-551f03e32008.png" />
</div>
<h1>INFORMATION</h1>
<h2>Environment variables : </h2>
<h3 style="color:blue;">Swagger </h3>
<table>
  <tr>
    <td><code>ASPNETCORE_ENVIRONMENT</code></td>
    <td><code>Development</code></td>
    <td><code>--env ASPNETCORE_ENVIRONMENT=Development</code></td>
  </tr>
</table>

<h3>Connection String  "MS SQL" </h3>
<table>
  <tr>
    <td><code>DB</code></td>
    <td><code>Your Connection string</code></td>
    <td><code>--env DB='Your Connection string' </code></td>
  </tr>
</table>

<h3>CORS Policy </h3>
<table>
  <tr>
    <td><code>CORS</code></td>
    <td><code>Your URL address</code></td>
    <td><code>--env CORS=http//:localhost:80,localhost.3000</code></td>
  </tr>
</table>
<p>You can add one or more CORE policies using a comma<code>( , )</code></p>
<h3>Mail Сonfig </h3>
<table>
  <tr>
    <td>SSL</td>
    <td><code>MailConfig:SSL</code></td>
    <td><code>--env MailConfig:SSL=true</code></td>
  </tr>
  <tr>
    <td>Port</td>
    <td><code>MailConfig:Port</code></td>
    <td><code>--env MailConfig:Port=445</code></td>
  </tr>
  <tr>
    <td>Password</td>
    <td><code>MailConfig:Password</code></td>
    <td><code>--env MailConfig:Password=qweqwesad@wW</code></td>
  </tr>
  <tr>
    <td>Mail</td>
    <td><code>MailConfig:Mail</code></td>
    <td><code>--env MailConfig:Mail=user@gmail.com</code></td>
  </tr>
  <tr>
   <td>Domain</td>
    <td><code>MailConfig:Domain</code></td>
    <td><code>--env MailConfig:Domain=smtp.gmail.com</code></td>
  </tr>
</table>
<h3>JWT Config</h3>
<table>
  <tr>
    <td>SecretKey</td>
    <td><code>JWT:SecretKey</code></td>
    <td><code>--env JWT:SecretKey=asdasdwafWFSAF </code></td>
  </tr>
 <tr>
   <td>Issuer</td>
    <td><code>JWT:Issuer</code></td>
    <td><code>--env JWT:Issuer=UWM </code></td>
  </tr>
 <tr>
    <td>Audience</td>
    <td><code>JWT:Audience</code></td>
    <td><code>--env JWT:Audience=UserOfUWM </code></td>
  </tr>
</table>
<br>
<p>Command:<code>docker run -p 4536:80/tcp ahmadck/uwm_asp_core_7</code>
<p><a href="https://github.com/ZLUKADARK/UWM/blob/master/Docker-compose-Example.yml">Docker-compose</a>

