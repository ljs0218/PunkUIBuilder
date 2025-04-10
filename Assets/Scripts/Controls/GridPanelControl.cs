using Game.Scripts.UI;
using Game.Scripts.Graphics;
using UnityEngine;
using UnityEngine.UI;
using Game.Scripts;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace Game.Scripts.UI
{
    [ExecuteAlways]
    public class GridPanelControl : Control
    {
        public Point cellSize { get; set; }
        public int childAlign { get; set; }
        public int constraint { get; set; }
        public int constraintCount { get; set; }
        public bool contentSizeFitterEnabled { get; set; }
        public bool horizontal { get; set; }
        public bool vertical { get; set; }
        public Point spacing { get; set; }
        public RectOff padding { get; set; }

#if UNITY_EDITOR
        private GridPanelControl()
        {
            EditorSceneManager.sceneSaved += (scene) =>
            {
                ApplyLayerGroup();
            };
        }

        private void ApplyLayerGroup()
        {
            if (this == null) { return; }
            
            GridLayoutGroup gridLayoutGroup = GetComponent<GridLayoutGroup>();
            if (gridLayoutGroup != null)
            {
                cellSize = new Point((int)gridLayoutGroup.cellSize.x, (int)gridLayoutGroup.cellSize.y);
                childAlign = (int)gridLayoutGroup.childAlignment;
                switch (gridLayoutGroup.constraint)
                {
                    case GridLayoutGroup.Constraint.FixedColumnCount:
                        constraint = 2;
                        break;
                    case GridLayoutGroup.Constraint.FixedRowCount:
                        constraint = 1;
                        break;
                    default:
                        constraint = 0;
                        break;
                }
                constraintCount = gridLayoutGroup.constraintCount;
                contentSizeFitterEnabled = gridLayoutGroup.GetComponent<ContentSizeFitter>() != null;
                horizontal = gridLayoutGroup.startAxis == GridLayoutGroup.Axis.Horizontal;
                vertical = gridLayoutGroup.startAxis == GridLayoutGroup.Axis.Vertical;
                spacing = new Point((int)gridLayoutGroup.spacing.x, (int)gridLayoutGroup.spacing.y);
                padding = new RectOff((int)gridLayoutGroup.padding.left, (int)gridLayoutGroup.padding.top,
                    (int)gridLayoutGroup.padding.right, (int)gridLayoutGroup.padding.bottom);
            }
        }
#endif
    }
}