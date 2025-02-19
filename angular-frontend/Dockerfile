# UI/Dockerfile
FROM node:14 AS build

WORKDIR /app
COPY ./angular-frontend/package*.json ./
RUN npm install
COPY ./angular-frontend ./
RUN npm run build --prod

FROM nginx:alpine
COPY --from=build /app/dist /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
