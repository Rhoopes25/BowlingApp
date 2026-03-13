// Import Vite's configuration helper
import { defineConfig } from 'vite'

// Import the React plugin so Vite understands React/JSX
import react from '@vitejs/plugin-react'

export default defineConfig({
  // Tell Vite to use the React plugin
  plugins: [react()],

  // Development server settings
  server: {
    // Lock the port to 3000 so it's always predictable
    // This way our .NET CORS config always knows where React lives
    port: 3000
  }
})