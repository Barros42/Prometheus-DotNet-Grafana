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

  const params = {
    headers: {
      'Content-Type': 'application/json',
    },
  };

  // Break The Payload Sometimes

  const shouldBreak = !!Math.round(Math.random())

  const body = shouldBreak ? payloadWithError : payload

  http.post('http://localhost:3000/User', body, params);
  http.get('http://localhost:3000/User');
}