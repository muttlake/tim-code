#ng.Dockerfile


#build stage
FROM node as build
RUN chown -R node:node /usr/local/lib/node_modules
RUN chown -R node:node /usr/local/bin 

# node user gets created, use it to install npm
USER node
RUN npm install -g @angular/cli

USER root
WORKDIR /docker
RUN ng new HelloNG
WORKDIR /docker/HelloNG
RUN ng build

# USER root
# RUN npm install @angular/cli
# #RUN ls -R -lrt | grep -e "ng"
# #RUN chown -R 777 *
# #WORKDIR node_modules/@angular/cli/bin
# RUN ls -l
# RUN node_modules/@angular/cli/bin/ng new HelloNG
# RUN ls -lrt
# WORKDIR /docker/HelloNG
# RUN ng build
# RUN pwd
# RUN ls -lrt


# #serve stage
FROM nginx:1.12
COPY --from=build /docker/HelloNG/dist /usr/share/nginx/html
RUN pwd
RUN ls -lrt
EXPOSE 80
# EOF