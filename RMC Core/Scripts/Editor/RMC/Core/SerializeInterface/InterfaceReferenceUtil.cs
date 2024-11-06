
using UnityEditor;
using UnityEngine;

//NOTE: Promote visibility, thus avoid any namespace
public class InterfaceReferenceUtil {
    static GUIStyle labelStyle;

    public static void OnGUI(Rect position, SerializedProperty property, GUIContent label, InterfaceArgs args) {
        InitializeStyleIfNeeded();
        
        var controlID = GUIUtility.GetControlID(FocusType.Passive) - 1;
        var isHovering = position.Contains(Event.current.mousePosition);
        var displayString = property.objectReferenceValue == null || isHovering ? $"({args.InterfaceType.Name})" : "*";
        DrawInterfaceNameLabel(position, displayString, controlID);
    }

    static void DrawInterfaceNameLabel(Rect position, string displayString, int controlID) {
        if (Event.current.type == EventType.Repaint) {
            const int additionalLeftWidth = 3;
            const int verticalIndent = 1;
            
            var content = EditorGUIUtility.TrTextContent(displayString);
            var size = labelStyle.CalcSize(content);
            var labelPos = position;
            
            labelPos.width = size.x + additionalLeftWidth;
            labelPos.x += position.width - labelPos.width - 18;
            labelPos.height -= verticalIndent * 2;
            labelPos.y += verticalIndent;
            labelStyle.Draw(labelPos, EditorGUIUtility.TrTextContent(displayString), controlID, DragAndDrop.activeControlID == controlID, false);
        }
    }
    
    static void InitializeStyleIfNeeded() {
        if (labelStyle != null) return;
        
        var style = new GUIStyle(EditorStyles.label) {
            font = EditorStyles.objectField.font,
            fontSize = EditorStyles.objectField.fontSize,
            fontStyle = EditorStyles.objectField.fontStyle,
            alignment = TextAnchor.MiddleRight,
            padding = new RectOffset(0, 2, 0, 0)
        };
        labelStyle = style;
    }
}

