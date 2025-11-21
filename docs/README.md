# Demo BFF con Next.js + REST + gRPC

## Estructura general
- backends/         → Servicios .NET (REST y gRPC)
- frontends/
  - bff-app-router  → BFF mediante Server Components
  - bff-api-routes  → BFF mediante API Routes
- docs/             → Diagramas y esta guía

## Cómo se conecta
```mermaid
graph LR
  subgraph Navegador
    U((Usuario)) --> UI
  end

  subgraph Next.js BFF
    UI -->|fetch| A[Server Component (versión A)]
    UI -->|fetch| B[API Route /api/products (versión B)]
  end

  A -->|HTTP| R[REST .NET]
  A -->|gRPC| G[gRPC .NET]
  B -->|HTTP| R
  B -->|gRPC| G
