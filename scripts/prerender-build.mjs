// Starts the .NET API, runs ng build (which prerenders pages from the API), then stops the API.
import { spawn, execSync } from 'node:child_process';
import { resolve } from 'node:path';

const serverDir = resolve(import.meta.dirname, '..', 'server');

console.log('Starting .NET API for prerendering...');
const api = spawn('dotnet', ['run'], { cwd: serverDir, stdio: 'pipe', shell: true });

// Wait for the API to be ready
await new Promise((ok) => {
  const check = async () => {
    try {
      const res = await fetch('http://localhost:5000/api/recipes');
      if (res.ok) return ok();
    } catch { /* not ready yet */ }
    setTimeout(check, 500);
  };
  check();
});
console.log('API is ready. Building Angular...');

try {
  execSync('npx ng build', { cwd: resolve(import.meta.dirname, '..'), stdio: 'inherit' });
} finally {
  api.kill();
  console.log('API stopped.');
}
