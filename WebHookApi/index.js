'use strict';

const DialogflowApp = require('actions-on-google').DialogflowApp; // Google Assistant helper library
const http = require('http');

const host = 'http://search';
const port = 80;

http.createServer(function (request, res) {
  const { headers, method, url } = request;
  console.log(`${method}: ${url}`);
  console.log('Dialogflow Request headers: ' + JSON.stringify(request.headers));
  console.log('Dialogflow Request body: ' + JSON.stringify(request.body));
  if(method !== 'POST') {
    sendBadRequest(res);
    return;
  }
  if(!url.includes('/webhook')){
    sendBadRequest(res);
    return;
  }
  const body = [];
  request.on('error', (err) => {
    console.error(err);
  }).on('data', (chunk) => {
    body.push(chunk);
  }).on('end', () => { 
    const obj = JSON.parse(Buffer.concat(body).toString());
    console.log(obj)
    if (obj && obj.result) {
      processV1Request(obj, res).then((output) => {
        res.setHeader('Content-Type', 'application/json');
        res.write(JSON.stringify(output));
        res.end();
      }).catch((error) => {
        // If there is an error let the user know
        console.log(error);
        res.setHeader('Content-Type', 'application/json');
        res.write(JSON.stringify({ 'speech': error, 'displayText': error }));
        res.end();
      });
    } else {
      sendBadRequest(res);
    }
});
}).listen(8080);

function sendBadRequest(res){
  console.log('Invalid Request');
  res.statusCode = 400;
  return res.end('Invalid Webhook Request');
}
/*
* Function to handle v1 webhook requests from Dialogflow
*/
function processV1Request (body, res) {
  return new Promise((resolve, reject) => {
    const parameters = body.result.parameters; 
    if(parameters['unit-currency'])
      parameters['unit-currency'] = parameters['unit-currency'].amount;
    const params = objectToParams(parameters);
    const url = '/products?' + params;
    console.log('send req to ' + host + ':' + port + url);
    http.get( host + ':' + port + url, (resp) => {
        const body = '';
        resp.on('data', (d) => { body += d; }); // store each response chunk
        resp.on('end', () => {
            const data = JSON.parse(body);
            console.log(data)
            const products = data.data;
            const responseToUser = {
              speech: products[0].name,
              displayText: products[0].productUrl, // displayed response
            };
            console.log(JSON.stringify(responseToUser))
            resolve(responseToUser);
        });

        resp.on('error', (err) => reject(err));
    });
  });
}

function objectToParams(obj) {
  return Object.keys(obj).map(function(k) {
    return encodeURIComponent(k) + "=" + encodeURIComponent(obj[k]);
  }).join('&');
}

function buildGoogleResponse(products){
  const app = new DialogflowApp();
  let res = app.buildRichResponse();
  products.forEach(product => {
    res = res.addBasicCard(
      app.buildBasicCard(product.description)
      .setTitle(product.name)
      .setSubtitle(product.brand)
      .addButton('Buy', product.productUrl)
      .setImage(product.imageUrl, 'product')
    );
  });
  return res;
}