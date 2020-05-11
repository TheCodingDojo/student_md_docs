# Generic Resources

## Online cheat sheets

- [Big O Cheat Sheet](https://www.bigocheatsheet.com/)
- [Emmet Cheat Sheet HTML shortcuts](https://docs.emmet.io/cheat-sheet/)

## [Vimeo Speed & Repeat Chrome Extension](Vimeo repeat & speed)

- speed up vimeo videos

## Patterns

- [Don’t Use Boolean Arguments, Use Enums](https://medium.com/better-programming/dont-use-boolean-arguments-use-enums-c7cd7ab1876a)

## Lessons

- [Security Vulnerability Lessons](https://www.hacksplaining.com/)

## Deployment

- [SSL](https://letsencrypt.org/)

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
