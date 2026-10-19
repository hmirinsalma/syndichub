# Diagrammes UML - SyndicHub

Ce dossier contient tous les diagrammes UML du projet SyndicHub, créés avec PlantUML.

## 📋 Liste des diagrammes

### Diagrammes de cas d'utilisation
- `use-cases-admin.puml` : Cas d'utilisation de l'administrateur
- `use-cases-syndic.puml` : Cas d'utilisation du syndic
- `use-cases-resident.puml` : Cas d'utilisation du résident

### Diagrammes de classes
- `class-diagram-complete.puml` : Diagramme de classes complet
- `class-diagram-domain.puml` : Diagramme des entités du domaine

### Diagrammes de séquence
- `sequence-login.puml` : Séquence d'authentification
- `sequence-payment-validation.puml` : Séquence de validation de paiement
- `sequence-ticket-lifecycle.puml` : Cycle de vie d'un ticket

### Diagrammes d'états
- `state-charge-call.puml` : États d'un appel de fonds
- `state-payment.puml` : États d'un paiement
- `state-ticket.puml` : États d'un ticket
- `state-installment.puml` : États d'une échéance
- `state-announcement.puml` : États d'une annonce

## 🛠️ Comment générer les diagrammes

### Prérequis
- PlantUML CLI ou extension VS Code

### Génération
```bash
# Avec PlantUML CLI
plantuml *.puml

# Avec extension VS Code
# Ouvrir le fichier .puml et utiliser Alt+D (ou Cmd+D sur macOS)
```

## 📚 Ressources

- [PlantUML Documentation](https://plantuml.com/)
- [PlantUML Cheat Sheet](https://plantuml.com/fr/guide)

---

**Note** : Les diagrammes seront créés progressivement au fil des phases de développement.
