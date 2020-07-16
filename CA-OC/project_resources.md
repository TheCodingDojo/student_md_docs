# Generic project resources

- see stack folder for specific project resources

## Project Ideas

- If you make something centered around helping people / communities, you may get free PR attention from the Dojo! We've had previous student's projects mentioned in news articles which is great to put on your resume!

1. Environmentalism
   Do you have an idea that would help society live in a more sustainable way? Create a project that makes “going green” a reality. This can include, but is not limited to:
   Reducing or monitoring carbon emissions
   Helping protect endangered species
   Reducing pollution or helping clean local neighborhoods or cities
   Ensuring everyone has access to clean drinking water and healthy food to eat
   Preventing deforestation or driving reforestation
   Improving waste disposal
   Improving the recycling process or recycling adoption

2. In-Need Individuals
   Are there communities or groups of individuals you want to support? Create a project that helps those in our society who need it most. This can include, but is not limited to:
   Supporting homeless individuals to find housing, food/water, employment, etc.
   Ending hunger in your area, or any area around the world
   Improving access to financial services or employment for impoverished individuals
   Helping veterans with PTSD or other service-related afflictions

3. Choose Your Own Cause
   Is there a different charity or non-profit that you support? Identify an organization working with an issue that you’re passionate about, then create a project that will help them reach their mission.

4. Choose Your Own Adventure
   Are you stumped or not interested in the above causes? Build any other project that showcases the technical skills you’ve learned in the program.

## List of deployed projects

- [havenshearth.com](https://havenshearth.com/welcome)
- [http://strivetogether.site/](http://strivetogether.site/)

## APIs

- [A collective list of free APIs](https://github.com/public-apis/public-apis)
- [Collective COVID-19 API List from Postman](https://covid-19-apis.postman.com/?mkt_tok=eyJpIjoiT1RrelpqUm1aamRqWlRJNSIsInQiOiJOeVRxZ0JXUW1hY21HekQ1U1hCXC9QZ00zSm9xc1F5UDluYWFIbkk3aFFFTWNUcURkVmd0dEtvOGJnbzVzdzFoODF0S0VpWXpDVElsNXZUY29iU0djOEIySDRLeWlFK3FrUFB6MlRCZUZnb1VkS3VPeG5VclZQZWx6dTZuVGNMVlEifQ%3D%3D)

## CSS

- [Complimentary Color Combinations](https://coolors.co/app)
- [How to instantly make your front end projects look better](https://www.freecodecamp.org/news/how-to-make-your-front-end-projects/)

## Deployment

- [Free SSL/TLS Certifications for HTTPS](https://letsencrypt.org/)

  - "if they set up DNS (route 53 is pretty easy) then it can be as simple as installing the certbot and running it"
  - example config `/etc/nginx/sites-available`

    - ```txt
      server {
          server_name 35.168.16.161 dojobracket.com;
          location / {
              include proxy_params;
              proxy_pass http://unix:/home/ubuntu/neo-bracket/server/neo-bracket.sock;
          }
          listen 443 ssl; # managed by Certbot
          ssl_certificate /etc/letsencrypt/live/dojobracket.com/fullchain.pem; # managed by Certbot
          ssl_certificate_key /etc/letsencrypt/live/dojobracket.com/privkey.pem; # managed by Certbot
          include /etc/letsencrypt/options-ssl-nginx.conf; # managed by Certbot
          ssl_dhparam /etc/letsencrypt/ssl-dhparams.pem; # managed by Certbot
      }
      server {
          if ($host = dojobracket.com) {
              return 301 https://$host$request_uri;
          } # managed by Certbot
          listen 80;
          server_name 35.168.16.161 dojobracket.com;
          return 404; # managed by Certbot
      }
      ```

---

## Mockups / Wireframe

- [https://miro.com/](https://miro.com/)
- [https://awwapp.com/](https://awwapp.com/)

## Logos

- [designevo](https://www.designevo.com/logo-maker/)

## Database

- [Online DB Diagram Tool](https://dbdiagram.io/d)
