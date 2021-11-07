FROM node:14 as build
WORKDIR /app
COPY . /app
RUN npm install
RUN npm run build --prod

## nginx
FROM nginx
COPY --from=build /app/build /usr/share/nginx/html

