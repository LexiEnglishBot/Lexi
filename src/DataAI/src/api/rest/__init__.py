from flask import Flask
from .ai import ai_bp

def create_app():
    app = Flask(__name__)
    # Register blueprints
    app.register_blueprint(ai_bp, url_prefix='/api')
    return app