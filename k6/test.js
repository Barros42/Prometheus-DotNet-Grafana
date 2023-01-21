import http from 'k6/http';

export const options = {
  discardResponseBodies: true,
  scenarios: {
    contacts: {
      executor: 'ramping-vus',
      startVUs: 10,
      stages: [
        { duration: '2m', target: 100 }, // below normal load
        { duration: '5m', target: 100 },
        { duration: '2m', target: 200 }, // normal load
        { duration: '5m', target: 200 },
        { duration: '2m', target: 300 }, // around the breaking point
        { duration: '5m', target: 300 },
        { duration: '2m', target: 400 }, // beyond the breaking point
        { duration: '5m', target: 400 },
        { duration: '10m', target: 0 }, // scale down. Recovery stage.
      ],
      gracefulRampDown: '5s',
    },
  },
};

export default function () {

  const payload = JSON.stringify({
    email: 'mdbf42@gmail.com',
    name: 'Matheus de Barros Fagionato',
  });

  const payloadWithError = JSON.stringify({
    email: 'mdbf42@gmail.com'
  })

  const paymentPayload = JSON.stringify({
    value: "42000",
    cardNumber: 1
  })

  const paymentPayloadWithError = JSON.stringify({
    value: "42000",
    cardNumber: 0
  })


  const params = {
    headers: {
      'Content-Type': 'application/json',
    },
  };

  // Break The Payload Sometimes

  let randUser = Math.floor(Math.random() * 2000);
  const shouldBreakUser = (randUser < 2)

  let randPayment = Math.floor(Math.random() * 1000);
  const shouldBreakPayment = (randPayment < 10)

  const bodyUser = shouldBreakUser ? payloadWithError : payload
  const bodyPayment = shouldBreakPayment ? paymentPayloadWithError : paymentPayload

  http.post('http://localhost:3000/User', bodyUser, params);
  http.post('http://localhost:3000/Payment', bodyPayment, params);
  http.get('http://localhost:3000/User');
}