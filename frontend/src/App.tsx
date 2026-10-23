import { useState, useEffect } from 'react';
import axios from 'axios';

interface ApiResponse<T> {
  success: boolean;
  message: string;
  data: T;
  errors: string[];
  statusCode: number;
  timestamp: string;
}

interface HealthData {
  status: string;
  timestamp: string;
  service: string;
  version: string;
}

function App() {
  const [health, setHealth] = useState<HealthData | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchHealth = async () => {
      try {
        setLoading(true);
        const response = await axios.get<ApiResponse<HealthData>>(
          'http://localhost:5050/api/v1/health'
        );
        
        if (response.data.success) {
          setHealth(response.data.data);
        } else {
          setError(response.data.message);
        }
      } catch (err) {
        setError(err instanceof Error ? err.message : 'Erreur inconnue');
      } finally {
        setLoading(false);
      }
    };

    fetchHealth();
  }, []);

  return (
    <div className="min-h-screen bg-gradient-to-br from-blue-50 to-indigo-100 flex items-center justify-center p-4">
      <div className="bg-white rounded-2xl shadow-xl p-8 max-w-2xl w-full">
        <div className="text-center mb-8">
          <h1 className="text-4xl font-bold text-indigo-600 mb-2">
            🏢 SyndicHub
          </h1>
          <p className="text-gray-600">
            Plateforme de gestion de syndic de copropriété
          </p>
        </div>

        <div className="bg-gray-50 rounded-xl p-6 border-2 border-gray-200">
          <h2 className="text-2xl font-semibold text-gray-800 mb-4 flex items-center">
            <span className="mr-3">🔌</span>
            État de l'API Backend
          </h2>

          {loading && (
            <div className="flex items-center justify-center py-8">
              <div className="animate-spin rounded-full h-12 w-12 border-b-2 border-indigo-600"></div>
              <p className="ml-4 text-gray-600">Connexion à l'API...</p>
            </div>
          )}

          {error && (
            <div className="bg-red-50 border-2 border-red-200 rounded-lg p-4">
              <div className="flex items-start">
                <span className="text-2xl mr-3">❌</span>
                <div>
                  <h3 className="text-lg font-semibold text-red-800 mb-1">
                    Erreur de connexion
                  </h3>
                  <p className="text-red-600">{error}</p>
                  <p className="text-sm text-red-500 mt-2">
                    Vérifiez que l'API est lancée sur http://localhost:5050
                  </p>
                </div>
              </div>
            </div>
          )}

          {health && (
            <div className="bg-green-50 border-2 border-green-200 rounded-lg p-4">
              <div className="flex items-start mb-4">
                <span className="text-2xl mr-3">✅</span>
                <div>
                  <h3 className="text-lg font-semibold text-green-800 mb-1">
                    Connexion réussie !
                  </h3>
                  <p className="text-green-600">L'API backend fonctionne correctement</p>
                </div>
              </div>

              <div className="grid grid-cols-2 gap-4 mt-4 bg-white rounded-lg p-4">
                <div>
                  <p className="text-sm text-gray-500 uppercase tracking-wide mb-1">
                    Service
                  </p>
                  <p className="text-lg font-semibold text-gray-800">
                    {health.service}
                  </p>
                </div>
                <div>
                  <p className="text-sm text-gray-500 uppercase tracking-wide mb-1">
                    Version
                  </p>
                  <p className="text-lg font-semibold text-gray-800">
                    {health.version}
                  </p>
                </div>
                <div>
                  <p className="text-sm text-gray-500 uppercase tracking-wide mb-1">
                    Statut
                  </p>
                  <p className="text-lg font-semibold text-green-600">
                    {health.status}
                  </p>
                </div>
                <div>
                  <p className="text-sm text-gray-500 uppercase tracking-wide mb-1">
                    Timestamp
                  </p>
                  <p className="text-sm font-mono text-gray-600">
                    {new Date(health.timestamp).toLocaleString('fr-FR')}
                  </p>
                </div>
              </div>
            </div>
          )}
        </div>

        <div className="mt-8 text-center text-sm text-gray-500">
          <p>Phase 1 - Foundations ✨</p>
          <p className="mt-1">Backend: .NET 8 | Frontend: React 18 + TypeScript + Tailwind</p>
        </div>
      </div>
    </div>
  );
}

export default App;
